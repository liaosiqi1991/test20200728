
using System.Windows.Forms;

namespace zlMedimgSystem.Services
{
    public interface IShowManager
    {
        bool ShowManager();

        bool ShowManager(IWin32Window owner);
    }
}
