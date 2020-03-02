using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_MvvmLight.Model;

namespace Wpf_MvvmLight.ViewModel
{
    public class NameViewModel:ViewModelBase
    {
        #region 字段
        private NameModel _nameModel;
        #endregion

        #region 属性
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

        #endregion

        #region 命令

        public RelayCommand UpdateName
        {
            get
            {
                return new RelayCommand(() =>
                {
                    UserName = "张三";
                    CompanyName = "百度";
                });
            }
        }

        #endregion
    }
}
