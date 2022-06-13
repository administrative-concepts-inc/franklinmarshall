<%@ Page Language="VB" MasterPageFile="RCMD_2019.master" AutoEventWireup="false" CodeFile="Help.aspx.vb" Inherits="Help" title="RCMD Help" Theme="PageSkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="MinorHead" style="padding-top:50px; text-align:center; font-weight:bold;">
        ENROLLMENT SUPPORT INFORMATION
    </div>
    <div style="padding:20px 20px 0px 20px;">
        If you are experiencing any problems during the ID Card retrieval process, please contact our Enrollment Services Department at:
    </div>
     <div style="padding:12px 0px 0px 40px; font-size:14px; line-height:20px;">
        <span class="ColumnHead">Phone:</span>&nbsp; <span style="font-weight:bold;">888-293-9229 Extension 600</span><br />
        <span class="ColumnHead">Email:</span>&nbsp; <a href="mailto:RCMD.Global@rcmd.com" style="font-weight:bold;">RCMD.Global@rcmd.com</a>
    </div>
    
    <div  class="ErrorText" style="padding-top:30px; padding-left:30px;  text-align:left; font-weight:bold;">
        <asp:LinkButton ID="lnkcomments"  runat="server" text="Submit Comments and Questions" Visible="true" Font-Bold="True" ForeColor="Red" Font-Underline="True">
        </asp:LinkButton>
    </div>
    <div id="dvthankyou" runat="server" visible="False"   class="MinorHead" style="padding-top:20px; padding-left:30px;  text-align:left; font-weight:bold;" >
        Thank you for submitting your comments/Questions.
    </div>
    <div id="dvcomments" runat="server" visible="false">
         <div class="ErrorText" style="padding:20px 20px 0px 60px;">
            <asp:ValidationSummary ID="vSummary" runat="server" DisplayMode="List" ForeColor="" ValidationGroup="vg1" />
        </div>
        <div>
            <table>
                <tr>
                    <td style="text-align: right; padding-right: 6px;">
                        <asp:Label ID="lblStudentID" runat="server" Text="Name" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" Width="120px" MaxLength="100" AutoCompleteType="Disabled" />
                        <asp:RequiredFieldValidator ID="vname" runat="server" ControlToValidate="txtName"
                            ErrorMessage="You Must Enter Your Name" Text="*" Display="Dynamic" CssClass="ErrorText"
                            ForeColor="" ValidationGroup="vg1" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; padding-right: 6px;">
                        <asp:Label ID="lblEmail" runat="server" Text="Email Id" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="255" Width="300px" AutoCompleteType="Disabled" />
                        <asp:RequiredFieldValidator ID="vEmail" runat="server" ErrorMessage="Email Address Can Not Be Blank"
                            Text="*" ValidationGroup="vg1" ControlToValidate="txtEmail" CssClass="ErrorText"
                            ForeColor="" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="vEmail1" runat="server" ControlToValidate="txtEmail"
                            CssClass="ErrorText" ForeColor="" ErrorMessage="Invalid Email Address" Text="*"
                            ValidationGroup="vg1" ValidationExpression="^.*@.*\..*$" Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; text-align: justify;">
                        <asp:Label ID="Label1" runat="server" Text="Comment Or Question" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtComment" runat="server" Width="300px" Height="100px" AutoCompleteType="Disabled"
                            TextMode="MultiLine" />
                        <asp:RequiredFieldValidator ID="vComment" runat="server" ControlToValidate="txtComment"
                            Text="*" ErrorMessage="You Must Enter Your Comment or Question" Display="Dynamic"
                            CssClass="ErrorText" ForeColor="" ValidationGroup="vg1" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" ValidationGroup="vg1" />
                        <asp:Button ID="btnClear" runat="server" Text="Clear" />
                    </td>
                </tr>
            </table>
        </div>    
    </div>   
</asp:Content>

