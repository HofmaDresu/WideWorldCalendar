using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WideWorldCalendar.ViewModels
{
    public class MasterPageItemViewModel : BaseViewModel
    {
        public Type TargetType { get; set; }
        private bool _isSelected;
        public bool IsSelected { get { return _isSelected; } set { SetProperty(ref _isSelected, value); } }
    }
}
