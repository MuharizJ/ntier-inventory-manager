using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFLStock.Entities {
    public class GroupEntity : BaseEntity {
        
        private string groupName;

        public string GroupName {
            get { return groupName; }
            set {
                groupName = value;
                this.NotifyPropertyChanged("GroupName");
            }
        }

        public override string ToString() {
            StringBuilder result = new StringBuilder();

            result.AppendLine("[Group Name - " + GroupName + "]");

            return result.ToString();
        }
    }
}
