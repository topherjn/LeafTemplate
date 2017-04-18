using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    string yaml = "---";
    string fileName = string.Empty;
    string output = string.Empty;
    List<string> groups = new List<string>();
    List<Category> categories = new List<Category>();

    protected void Page_Load(object sender, EventArgs e)
    {
       
        StreamReader sr = new StreamReader(HostingEnvironment.MapPath(@"~/App_Data/categories.txt"));
        string line;
        string[] words;

        while((line = sr.ReadLine()) != null)
        {
            words = line.Split(',');
            groups.Add(words[0]);

           for(int i = 1; i < words.Length; i++)
            {
                categories.Add(new Category(words[i], words[0]));
            }
        }

        sr.Close();

        foreach(var item in categories)
        {
            Response.Write(item + "<br />");
        }
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        output += yaml + "\n";
        output += layoutLabel.Text + " " + layoutDDL.SelectedValue + "\n";
        output += titleLabel.Text + " " + "\"" + titleTextBox.Text + "\"\n";
        output += titleurlLabel.Text + " " + "\"" + titleurlTextBox.Text + "\"\n";
        output += authorLabel.Text + " " + authorTextBox.Text + "\n";
        output += groupsLabel.Text + " " + groupsDDL.SelectedValue + "\n";
        output += categoriesLabel.Text + " " + categoriesDDL.SelectedValue + "\n";
        output += topicsLabel.Text + " " + topicsDDL.SelectedValue + "\n";
        output += summaryLabel.Text + "\n     " + summaryTextBox.Text + "\n";
        output += citeLabel.Text + "\n     " + citeTextBox.Text + "\n";
        output += pubdateLabel.Text + " " + pubdateTextBox.Text + "\n";
        output += "added-date: " + DateTime.Now.Date.ToString("yyyy-MM-dd") + "\n";
        output += resourcetypeLabel.Text + " " + resourcetypeDDL.SelectedValue + "\n";
        output += yaml + "\n";

        WriteFile();


   
    }

    private void constructFileName()
    {
        fileName += 
            pubdateTextBox.Text + 
            "-" + titleTextBox.Text
            + ".md";

        fileName = fileName.Replace(' ', '-').ToLower();
        fileName = fileName.Replace("?", "");
        fileName = fileName.Replace(":", "");
        fileName = fileName.Replace(",", "");

    }

    protected void clearButton_Click(object sender, EventArgs e)
    {
        CleartextBoxes(this);  
    }

    public void CleartextBoxes(Control parent)
    {

        foreach (Control x in parent.Controls)
        {
            if ((x.GetType() == typeof(TextBox)))
            {

                ((TextBox)(x)).Text = "";
            }

            if (x.HasControls())
            {
                CleartextBoxes(x);
            }
        }

        pubdateTextBox.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
    }

    private void WriteFile()
    {
        constructFileName();
        byte[] toBytes = Encoding.ASCII.GetBytes(output);

        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "text/plain";
        Response.AppendHeader("content-disposition", "attachment; filename=" + fileName);
     //   Response.AppendHeader("content-length", toBytes.Length);
        Response.BinaryWrite(toBytes);
        Response.Flush();
        Response.End();
    }


    protected void groupsDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
}