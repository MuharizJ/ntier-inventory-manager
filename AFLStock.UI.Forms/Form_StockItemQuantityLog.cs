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
    public partial class Form_StockItemQuantityLog : Form {
        private WCF.Client.ServiceReference.StockItemMaster_POCO _stockItemPOCO;

        public Form_StockItemQuantityLog(WCF.Client.ServiceReference.StockItemMaster_POCO stockItemPOCO) {
            InitializeComponent();

            _stockItemPOCO = stockItemPOCO;
        }

        private void Form_StockItemQuantityLog_Load( object sender, EventArgs e ) {
            label_Category.Text = _stockItemPOCO.StockCategory;
            label_DesignNumber.Text = _stockItemPOCO.DesignNumber;
            label_SubCode.Text = _stockItemPOCO.SubCode;
            label_UnitType.Text = _stockItemPOCO.UnitType;

            label_QtyTotal.Text = _stockItemPOCO.Quantity.ToString();

            dataGridView_QtyLogList.AutoGenerateColumns = false;
            dataGridView_QtyLogList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewTextBoxColumn colTB_Qty = new DataGridViewTextBoxColumn();
            colTB_Qty.DataPropertyName = "Quantity";
            colTB_Qty.HeaderText = "Quantity";
            dataGridView_QtyLogList.Columns.Add( colTB_Qty );

            FontFamily family = new FontFamily( "Times New Roman" );
            Font font = new Font( family, 14.0f );
            dataGridView_QtyLogList.Font = font;

            List<DoubleWithProperty> quantityList = new List<DoubleWithProperty>();
            foreach (double d in _stockItemPOCO.QuantityList) {
                quantityList.Add(new DoubleWithProperty(d));
            }

            dataGridView_QtyLogList.DataSource = new List<DoubleWithProperty>(quantityList);
        }

        private void button_Close_Click( object sender, EventArgs e ) {
            this.Close();
        }

        private class DoubleWithProperty {
            public double Quantity { get; set; }

            public DoubleWithProperty(double d) {
                Quantity = d;
            }
        }
    }
}
