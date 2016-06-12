using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMM
{

    [ImplementPropertyChanged]
    public class Settings //: INotifyPropertyChanged
 

    {

        public int ParyPłodne { get; set; } = 0;

        public int ParyNiePłodne { get; set; } = 0;

        public int Wilki { get; set; } = 0;
        
        public int Lisy { get; set; } = 0;

        public int LiczbaMiesiecy { get; set; } = 0;


    }
}
