using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_MvvmLight.Model
{
    class NameModel
    {
        #region 字段

        private string _userName;
        private string _companyName;

        #endregion

        #region 属性

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        #endregion
    }
}
