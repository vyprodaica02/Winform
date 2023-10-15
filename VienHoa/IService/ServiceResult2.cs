using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;

namespace VienHoa.IService
{
    public class ServiceResult2
    {
        public bool Error { get; }
        public string ErrorMessage { get; }

        private ServiceResult2(bool error, string errorMessage)
        {
            Error = error;
            ErrorMessage = errorMessage;
        }

        public static ServiceResult2 Success(string errorMessage)
        {

            return new ServiceResult2(true, errorMessage);
        }

        public static ServiceResult2 Failed(string errorMessage)
        {
           
            return new ServiceResult2(false, errorMessage);
        }
    }
}
