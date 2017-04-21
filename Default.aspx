<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style3 {
        }

        .auto-style4 {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:Label ID="layoutLabel" runat="server" Text="layout:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="layoutDDL" runat="server">
                            <asp:ListItem>leaf-node</asp:ListItem>
                            <asp:ListItem>page</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="titleLabel" runat="server" Text="title:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="titleTextBox" runat="server" Width="659px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="titleurlLabel" runat="server" Text="title-url:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="titleurlTextBox" runat="server" Height="22px" Width="667px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="authorLabel" runat="server" Text="author:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="authorTextBox" runat="server" Height="22px" Width="667px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="groupsLabel" runat="server" Text="groups:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="groupsDDL" runat="server" OnSelectedIndexChanged="groupsDDL_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="categoriesLabel" runat="server" Text="categories:"></asp:Label>
                    </td>
                    <td>
                        <asp:ListBox runat="server" ID="categoriesListBox" SelectionMode="multiple"></asp:ListBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="topicsLabel" runat="server" Text="topics:"></asp:Label>
                    </td>
                    <td>
                        <asp:ListBox ID="topicsListBox" runat="server" SelectionMode="Multiple">
                            <asp:ListItem>biographies</asp:ListItem>
                            <asp:ListItem>in-the-media</asp:ListItem>
                            <asp:ListItem>interviews</asp:ListItem>
                            <asp:ListItem>introductory-resources</asp:ListItem>
                            <asp:ListItem>introductory-resources-video</asp:ListItem>
                            <asp:ListItem>ongoing-projects</asp:ListItem>
                            <asp:ListItem>scholarly-readings</asp:ListItem>
                        </asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="summaryLabel" runat="server" Text="summary: &gt;"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="summaryTextBox" runat="server" Height="134px" Width="667px" CssClass="auto-style3" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="citeLabel" runat="server" Text="cite: |"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="citeTextBox" runat="server" Height="70px" Width="667px" CssClass="auto-style4" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>


                <tr>
                    <td>
                        <asp:Label ID="pubdateLabel" runat="server" Text="pub-date:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="pubdateTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="resourcetypeLabel" runat="server" Text="resource-type:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="resourcetypeDDL" runat="server">
                            <asp:ListItem>external-page</asp:ListItem>
                            <asp:ListItem>internal-page</asp:ListItem>
                            <asp:ListItem>interview-mp3</asp:ListItem>
                            <asp:ListItem>pdf-document</asp:ListItem>
                            <asp:ListItem>video-course</asp:ListItem>
                            <asp:ListItem>video</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="clearButton" runat="server" Text="Clear" OnClick="clearButton_Click" />
                    </td>
                    <td>
                        <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click" />
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
