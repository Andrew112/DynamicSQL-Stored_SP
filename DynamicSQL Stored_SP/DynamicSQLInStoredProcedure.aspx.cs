using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DynamicSQL_Stored_SP;
using System.Globalization;
using System.Web.UI;





namespace DynamicSQL_Stored_SP
{
	public partial class DynamicSQLInStoredProcedure : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{ }

		protected void btnSearch_Click(object sender, EventArgs e)
		{
			string connectionStr = ConfigurationManager
				.ConnectionStrings["connectionStr"].ConnectionString;
			using (SqlConnection con = new SqlConnection(connectionStr))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = con;
				cmd.CommandText = "spSearchEmployeesGoodDynamicSQL";
				cmd.CommandType = CommandType.StoredProcedure;

				if (inputFirstname.Value.Trim() != "")
				{
					SqlParameter param = new SqlParameter("@FirstName",
						inputFirstname.Value);
					cmd.Parameters.Add(param);
				}

				if (inputLastname.Value.Trim() != "")
				{
					SqlParameter param = new SqlParameter("@LastName",
						inputLastname.Value);
					cmd.Parameters.Add(param);
				}

				if (inputGender.Value.Trim() != "")
				{
					SqlParameter param = new SqlParameter("@Gender",
						inputGender.Value);
					cmd.Parameters.Add(param);
				}

				if (inputSalary.Value.Trim() != "")
				{
					SqlParameter param = new SqlParameter("@Salary",
						inputSalary.Value);
					cmd.Parameters.Add(param);
				}

				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				gvSearchResults.DataSource = rdr;
				gvSearchResults.DataBind();
			}
		}
	}
}