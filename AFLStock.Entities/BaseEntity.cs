using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace AFLStock.Entities {
    public abstract class BaseEntity : INotifyPropertyChanged {
        private int id = int.MinValue;
        private bool markedForDeletion = false;

        public const string EQUALITY_STRING_EQUAL = "EQUAL TO";
        public const string EQUALITY_STRING_GREATER_THAN = "GREATER THAN";
        public const string EQUALITY_STRING_LESS_THAN = "LESS THAN";

        public static string[] EQUALITY_LIST = { EQUALITY_STRING_EQUAL, EQUALITY_STRING_GREATER_THAN, EQUALITY_STRING_LESS_THAN };

        public bool Dirty { get; set; }

        public int ID {
            get { return id; }
            set {
                id = value;
                this.NotifyPropertyChanged( "ID" );
            }
        }

        public bool MarkedForDeletion {
            get { return markedForDeletion; }
            set {
                markedForDeletion = value;
                this.NotifyPropertyChanged( "MarkedForDeletion" );
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged( string name ) {
            if ( PropertyChanged != null ) {
                PropertyChanged( this, new PropertyChangedEventArgs( name ) );
                Dirty = true;
            }
        }

        public override bool Equals( object obj ) {
            // WTF? I've no idea, don't ask me --> technically you should be smarter than me by now, so you should know why
            if ( obj == null || obj.GetType().FullName.Equals( "System.DBNull" ) ) {
                return false;
            }
            else {
                return ( ID == ( (BaseEntity) obj ).ID );
            }
        }

        public virtual void ResetEntity() {
            ID = int.MinValue;
        }
    }
}
