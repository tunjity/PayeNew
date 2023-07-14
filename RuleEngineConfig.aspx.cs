using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RuleEngineConfig : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        loaddata();
    }

    public void loaddata()
    {
        string qry = "select * from RuleEngine where RuleStatus='A'";
        DataTable dt = new DataTable();
        dt = PAYEClass.fetchdata(qry);
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["RuleDesc"].ToString().Trim() == "PENSION")
                {
                    lblpensionformulaold.Text = dt.Rows[i]["RuleFormula"].ToString().Trim();
                }
                if (dt.Rows[i]["RuleDesc"].ToString().Trim() == "NHF")
                {
                    lblnhfformulaold.Text = dt.Rows[i]["RuleFormula"].ToString().Trim();
                }
                if (dt.Rows[i]["RuleDesc"].ToString().Trim() == "NHIS")
                {
                    lblnhisformulaold.Text = dt.Rows[i]["RuleFormula"].ToString().Trim();
                }
                if (dt.Rows[i]["RuleDesc"].ToString().Trim() == "CRA1")
                {
                    lblcra1formulaold.Text = dt.Rows[i]["RuleFormula"].ToString().Trim();
                }
                if (dt.Rows[i]["RuleDesc"].ToString().Trim() == "CRA2")
                {
                    lblcra2formulaold.Text = dt.Rows[i]["RuleFormula"].ToString().Trim();
                }

            }
 
        }
    }


    protected void chkpensionformulacopy_CheckedChanged(object sender, EventArgs e)
    {
        changetext(chkpensionformulacopy, txtpensionformulanew, lblpensionformulaold);
    }
    protected void chknhfformulacopy_CheckedChanged(object sender, EventArgs e)
    {
        changetext(chknhfformulacopy, txtnhfformulanew, lblnhfformulaold);
    }
    protected void chknhisformulacopy_CheckedChanged(object sender, EventArgs e)
    {
        changetext(chknhisformulacopy, txtnhisformulanew, lblnhisformulaold);
    }
    protected void chkcra1formulacopy_CheckedChanged(object sender, EventArgs e)
    {
        changetext(chkcra1formulacopy, txtcra1formulanew, lblcra1formulaold);
    }
    protected void chkcra2formulacopy_CheckedChanged(object sender, EventArgs e)
    {
        changetext(chkcra2formulacopy, txtcra2formulanew, lblcra2formulaold);
    }

    public void changetext(CheckBox c, TextBox t, Label l)
    {
        if (c.Checked)
        {
            t.Text = l.Text;
        }
        else
        {
            t.Text = "";
        }
    }
    protected void btnNewRule_Click(object sender, EventArgs e)
    {
        SqlParameter[] pram = new SqlParameter[6];
        pram[0] = new SqlParameter("@pensionformula", txtpensionformulanew.Text.Trim());
        pram[1] = new SqlParameter("@nhfformula", txtnhfformulanew.Text.Trim());
        pram[2] = new SqlParameter("@nhisformula", txtnhisformulanew.Text.Trim());
        pram[3] = new SqlParameter("@cra1formula", "NA");
        pram[4] = new SqlParameter("@cra2formula", "NA");
        pram[5] = new SqlParameter("@SucessID", "1");
        pram[5].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(PAYEClass.connection, CommandType.StoredProcedure, "ADM_INS_NEW_RULE", pram);
        int status = int.Parse(pram[5].Value.ToString());
        if (status == 1)
        {
            showmsg(1, "Rule Created Successfully");
        }
        else
        {
            showmsg(2, "Error in creating rule. Transaction Rolledback");
        }
    }

    public void showmsg(int id, string msg)
    {
        if (id == 1)
        {
            divmsg.Style.Add("display", "");
            divmsg.InnerHtml = "<i class='menu-icon fa fa-check-circle' style='font-size:20px !important;'></i>&nbsp;" + msg + "";
            divmsg.Attributes.Add("class", "msg");
        }
        else if (id == 2)
        {
            divmsg.Style.Add("display", "");
            divmsg.InnerHtml = "<i class='menu-icon fa fa-warning (alias)' style='font-size:20px !important;'></i>&nbsp;" + msg + "";
            divmsg.Attributes.Add("class", "msg-error");
        }
        else
        {
            divmsg.Style.Add("display", "none");
        }
    }
}