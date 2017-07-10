using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AFLStock.Consumer;
using AFLStock.Entities;

namespace AFLStock.UI.Forms {
    public partial class Form_StockCategories : Form {
        public Form_StockCategories() {
            InitializeComponent();
        }

        private StockConsumerLocal stockClient;
        private BindingList<StockCategoryEntity> _categoryList;
        private List<StockCategoryEntity> _deletedStockCategories;

        private string _categoryNamePriorToEdit = "";

        private void Form_StockCategories_Load( object sender, EventArgs e ) {
            stockClient = StockConsumerLocal.getClientInstance();
            _categoryList = stockClient.getCategories(); // initially load all stock categories
            _deletedStockCategories = new List<StockCategoryEntity>(); // this list will track any existing categories that are to be deleted in the next call to save

            dataGridView_CategoryNames.AutoGenerateColumns = false;
            dataGridView_CategoryNames.AutoSize = true;
            dataGridView_CategoryNames.DataSource = _categoryList;

            DataGridViewTextBoxColumn colTB = new DataGridViewTextBoxColumn();
            colTB.DataPropertyName = "CategoryName";
            colTB.HeaderText = "Category Name";
            dataGridView_CategoryNames.Columns.Add( colTB );

            dataGridView_CategoryNames.ClearSelection();

            textBox_CategoryName.KeyPress += new KeyPressEventHandler( textBox_CategoryName_KeyPress );
        }


        private void textBox_CategoryName_KeyPress( object sender, KeyPressEventArgs e ) {
            if ( e.KeyChar == 13 ) {
                button_NewCategory.PerformClick();
            }
        }

        private void button_NewCategory_Click( object sender, EventArgs e ) {
            string newCatName = textBox_CategoryName.Text;
            if ( MessageBox.Show( "CREATE a NEW Category: " + newCatName + "?", "Confirm Creation", MessageBoxButtons.YesNo, MessageBoxIcon.Information ) == DialogResult.Yes ) {
                StockCategoryEntity newCategory = new StockCategoryEntity();
                newCategory.CategoryName = newCatName;
                newCategory.Mutable = !checkBox_QtyLog.Checked;
                _categoryList.Add( newCategory );
            }

            textBox_CategoryName.Text = "";
            dataGridView_CategoryNames.Refresh();
            dataGridView_CategoryNames.ClearSelection();
        }


        private void button_Cancel_Click( object sender, EventArgs e ) {
            if ( MessageBox.Show( "Exit Without Saving?", "Warning - Possible Loss of Data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning ) == DialogResult.Yes ) {
                this.Close();
            }
            this.Close();
        }

        private void button_Commit_Click( object sender, EventArgs e ) {
            string deletions = "";

            if ( _deletedStockCategories.Count > 0 ) {
                deletions += "\nDeletions - [";

                foreach ( StockCategoryEntity stockCatEnt in _deletedStockCategories ) {
                    deletions += stockCatEnt.CategoryName + "\n";
                }

                deletions += "]";
            }

            if ( MessageBox.Show( "Do you wish to save all changes (and deletions) and Exit?" + deletions, "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation ) == System.Windows.Forms.DialogResult.Yes ) {
                foreach ( StockCategoryEntity deletedStockCatEnt in _deletedStockCategories ) {
                    // this must be added back as it needs to deleted in the datastore
                    if ( !_categoryList.Contains( deletedStockCatEnt ) ) {
                        _categoryList.Add( deletedStockCatEnt );
                    }
                }
                _deletedStockCategories = new List<StockCategoryEntity>();

                stockClient.saveStockCategoryList( _categoryList );
                this.Close();
            }
        }

        private void dataGridView_CategoryNames_UserDeletingRow( object sender, DataGridViewRowCancelEventArgs e ) {
            DataGridViewSelectedRowCollection selectedRows = dataGridView_CategoryNames.SelectedRows;

            // even though multi-select is off, this is a clean way of handling this (only one row here)
            foreach ( DataGridViewRow selectedRow in selectedRows ) {
                StockCategoryEntity selectedItem = (StockCategoryEntity) selectedRow.DataBoundItem;
                if ( selectedItem.ID != int.MinValue ) {
                    if ( MessageBox.Show( "Are you sure you want to DELETE the Category: " + selectedItem.CategoryName + "?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation ) == DialogResult.Yes ) {
                        if ( !_deletedStockCategories.Contains( selectedItem ) ) {
                            _deletedStockCategories.Add( selectedItem );
                            selectedItem.MarkedForDeletion = true;
                        }
                    }
                    else {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void dataGridView_CategoryNames_CellBeginEdit( object sender, DataGridViewCellCancelEventArgs e ) {
            if ( dataGridView_CategoryNames.CurrentCell != null && dataGridView_CategoryNames.CurrentCell.Value != null ) {
                if ( dataGridView_CategoryNames.CurrentCell.Value.ToString().Equals( StockItemSelector_Control.NOSELECTION_CATEGORY ) ) {
                    MessageBox.Show( "This is a default Category and cannot be changed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    dataGridView_CategoryNames.CancelEdit();
                    return;
                }

                _categoryNamePriorToEdit = dataGridView_CategoryNames.CurrentCell.Value.ToString();
            }
        }

        private void dataGridView_CategoryNames_CellEndEdit( object sender, DataGridViewCellEventArgs e ) {
            if ( !_categoryNamePriorToEdit.Equals( dataGridView_CategoryNames.CurrentCell.Value )
                    && MessageBox.Show( "Do you wish to change the category called: " + _categoryNamePriorToEdit + " to: " +
                        dataGridView_CategoryNames.CurrentCell.Value.ToString() + "?"
                        , "Confirm Deletion"
                        , MessageBoxButtons.YesNo
                        , MessageBoxIcon.Exclamation ) == DialogResult.No ) {

                // only change the value if the user says Yes to changing, if he says no, reset the current
                // cell value to the value-prior to edit
                dataGridView_CategoryNames.CurrentCell.Value = _categoryNamePriorToEdit;
            }
        }
    }
}
