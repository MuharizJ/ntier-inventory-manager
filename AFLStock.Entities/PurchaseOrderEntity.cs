using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;

namespace AFLStock.Entities {
    public class PurchaseOrderEntity : BaseEntity {
        private string externalId, supplier, details;
        private DateTime transDate = DateTime.Today;
        private BindingList<PurchaseLogEntity> purchaseLogList;

        public string ExternalReferenceId {
            get { return externalId; }
            set {
                externalId = value;
                this.NotifyPropertyChanged( "ExternalReferenceId" );
            }
        }

        public string Supplier {
            get {
                return supplier;
            }
            set {
                supplier = value;
                this.NotifyPropertyChanged( "Supplier" );
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

        public BindingList<PurchaseLogEntity> PurchaseLogList {
            get {
                return purchaseLogList;
            }
            set {
                purchaseLogList = value;
                this.NotifyPropertyChanged( "PurchaseLogList" );
            }
        }
    }
}
