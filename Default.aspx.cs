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
    static List<string> groups = new List<string>();
    static List<Category> categories = new List<Category>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            StreamReader sr = new StreamReader(HostingEnvironment.MapPath(@"~/App_Data/categories.txt"));
            string line;
            string[] words;

            while ((line = sr.ReadLine()) != null)
            {
                words = line.Split(',');
                groups.Add(words[0]);

                for (int i = 1; i < words.Length; i++)
                {
                    categories.Add(new Category(words[i], words[0]));
                }
            }

            sr.Close();

            groupsDDL.DataSource = groups;
            groupsDDL.DataBind();

            filterCategories();
        }


    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        BuildOutputString();

        WriteFile();
    }

    private void BuildOutputString()
    {
        output += yaml + "\n";
        output += layoutLabel.Text + " " + layoutDDL.SelectedValue + "\n";
        output += titleLabel.Text + " " + "\"" + titleTextBox.Text + "\"\n";
        output += titleurlLabel.Text + " " + "\"" + titleurlTextBox.Text + "\"\n";

        string[] authors = authorTextBox.Text.Split(',');

        output += authorLabel.Text + " ";
        output += "[ ";

        foreach (string author in authors)
        {
            output += "\"" + author.Trim() + "\", ";
        }

        output = output.TrimEnd(' ');
        output = output.TrimEnd(',');
        output += " ]\n";
        output += groupsLabel.Text + " " + groupsDDL.SelectedValue + "\n";
        output += categoriesLabel.Text + " [ ";

        foreach (ListItem item in categoriesListBox.Items)
        {
            if (item.Selected)
            {
                output += "\"" + item.Value + "\", ";
            }
        }
        output = output.TrimEnd(' ');
        output = output.TrimEnd(',');
        output += " ]\n";
        output += topicsLabel.Text + " " + topicsDDL.SelectedValue + "\n";
        output += summaryLabel.Text + "\n     " + summaryTextBox.Text + "\n";
        output += citeLabel.Text + "\n     " + citeTextBox.Text + "\n";
        output += pubdateLabel.Text + " " + pubdateTextBox.Text + "\n";
        output += "added-date: " + DateTime.Now.Date.ToString("yyyy-MM-dd") + "\n";
        output += resourcetypeLabel.Text + " " + resourcetypeDDL.SelectedValue + "\n";
        output += yaml + "\n";
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
        categoriesListBox.ClearSelection();
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
        filterCategories();
    }

    private void filterCategories()
    {
        categoriesListBox.Items.Clear();

        foreach (Category item in categories)
        {
            if(item.Group == groupsDDL.SelectedValue)
            {
          
                categoriesListBox.Items.Add(item.Name);
            }
        }
    }
}