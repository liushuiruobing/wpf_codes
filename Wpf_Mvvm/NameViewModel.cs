using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wpf_Mvvm
{
    public class RelayCommand : ICommand
    {
        private readonly Func<bool> _canExecute;
        private readonly Action _execute;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested += value;
            }

            remove
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        public RelayCommand(Action execute):this(execute, null)
        {

        }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }

    public class NameViewModel:INotifyPropertyChanged
    {
        #region 字段

        private NameModel _nameModel;

        #endregion

        #region 属性

        public event PropertyChangedEventHandler PropertyChanged;

        public string UserName
        {
            get { return _nameModel.UserName; }
            set
            {
                _nameModel.UserName = value;
                RaisePropertyChanged("UserName");
            }
        }

        public string CompanyName
        {
            get { return _nameModel.CompanyName; }
            set
            {
                _nameModel.CompanyName = value;
                RaisePropertyChanged("CompanyName");
            }
        }

        #endregion

        #region 方法

        public NameViewModel()
        {
            _nameModel = new NameModel();        
            _nameModel.UserName = "流水若冰";
            _nameModel.CompanyName = "太阳";
        }

        private void RaisePropertyChanged(string propertyName)
        {
            //if (PropertyChanged != null)
            //    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region 命令
        public ICommand UpdateName
        {
            get { return new RelayCommand(UpdateNameExecute, CanUpdateNameExecute); }
        }

        public void UpdateNameExecute()
        {
            this.UserName = "张三";
            this.CompanyName = "百度";
        }

        public bool CanUpdateNameExecute()
        {
            return true;
        }

        #endregion
    }
}
