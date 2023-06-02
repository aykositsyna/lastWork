using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lastWork
{
    internal class Logic
    {
        public ObservableCollection<Discipline> Subjects { get; set; }

        public Discipline SelectedSubject { get; set; }

    }
}
