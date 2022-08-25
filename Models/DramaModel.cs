using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DramaReview.Models
{
    public class DramaModel
    {
        public int ID { get; set; }
        public string Tytul { get; set; }
        //public string RokObejrzenia { get; set; }
        public int OcenaAktorstwo { get; set; }
        public int OcenaFabula { get; set; }
        public int OcenaOST { get; set; }
        public int OcenaZakonczenie { get; set; }
        public int OcenaWizualna { get; set; }
        public int OcenaSrednia { get; set; }
        public string Zdjecie { get; set; }
    }

    public class DramaViewModel
    {
        public ObservableCollection<DramaModel> TwojeDramy { get; set; } = new ObservableCollection<DramaModel>(GlobalConfig.Connection.GetDramas());        
    
    }
}
