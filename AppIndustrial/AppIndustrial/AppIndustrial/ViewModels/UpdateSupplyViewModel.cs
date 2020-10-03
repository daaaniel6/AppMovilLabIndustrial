using AppIndustrial.Models.SupplyDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AppIndustrial.ViewModels
{
    class UpdateSupplyViewModel : INotifyPropertyChanged
    {

        Supply _selectedSupply; 
        Supply SelectedSupply {
            get
            {
                return _selectedSupply;
            }

            set
            {
                _selectedSupply = value;
                OnPropertyChanged();
            }
        }

        measure SupplyMeasure{ get; set; }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
