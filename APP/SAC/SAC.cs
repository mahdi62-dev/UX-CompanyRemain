using System.Data;

namespace APP
{
    public class SAC
    {
        public bool CheckAuth(DataTable dtSACUserPermission, int ModID, int ActionID)
        {
            bool hasAuth = false;

            int rowCount = dtSACUserPermission.Select("ModID=" + ModID + " AND ActionID=" + ActionID).Length;

            if (rowCount > 0)
            {
                hasAuth = true;
            }

            return hasAuth;
        }
    }
}