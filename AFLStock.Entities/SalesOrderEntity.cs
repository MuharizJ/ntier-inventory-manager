using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;

namespace AFLStock.Entities {
    public class SalesOrderEntity : BaseEntity {
        private string externalId, customer, details;
        private DateTime transDate = DateTime.Today;
        private BindingList<SalesLogEntity> saleItemList;

        public string ExternalReferenceId {
            get { return externalId; }
            set {
                externalId = value;
                this.NotifyPropertyChanged( "ExternalReferenceId" );
            }
        }

        public string Customer {
            get {
                return customer;
            }
            set {
                customer = value;
                this.NotifyPropertyChanged( "Customer" );
            }
        }

        public string Details {
            get {
                return details;
            }
            set {
                details = value;
                this.NotifyPropertyChanged( "Details" );
            }
        }

        public DateTime TransactionDate {
            get {
                return transDate;
            }
            set {
                transDate = value;
                this.NotifyPropertyChanged( "TransactionDate" );
            }
        }

        public BindingList<SalesLogEntity> SalesLogList {
            get {
                return saleItemList;
            }
            set {
                saleItemList = value;
                this.NotifyPropertyChanged( "SalesLogList" );
            }
        }
    }
}
