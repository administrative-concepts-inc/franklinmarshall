<%@ Page Language="VB" MasterPageFile="RCMD_2019.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="RCMDinfosite_Default" title="Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <%--<div id ="divError" runat="server" class="ErrorText" style="" visible="false">
        </div>--%>
        <div id="divOptions" runat="server" class="MainSelections" style="font-size:14pt; text-align:center;" visible="true">
            <table class="icon" style="padding-top:15px; vertical-align:bottom; margin-left:auto; margin-right:auto;" >
                <tr>                
                    <td>
                        <div style="text-align:center;">
                            <h3 style="padding-bottom:4px;">
                                <a href="Benefits.aspx" style="font-size: 11pt;  font-weight: 700; text-decoration:none;">                        
                                    BENEFITS
                                </a>
                            </h3>
                            <a href="Benefits.aspx" >                        
                                 <img alt="" src="Images/WS_Pic1.jpg" height="200px" onmouseover="src='Images/WS_Pic1_Hover.jpg'" onmouseout="src='Images/WS_Pic1.jpg'"/>
                            </a>                          
                        </div>                                                         
                    </td>
                    <%--<td style="padding-left: 15px;">
                        <div style="text-align:center;">
                            <h3 style="padding-bottom:4px;">
                                <a href="SemesterBenefits.aspx" style="font-size: 11pt;  font-weight: 700;text-decoration:none;">                        
                                    SEMESTER BENEFITS
                                </a>
                            </h3>
                            <a href="SemesterBenefits.aspx">                        
                                 <img alt="" src="Images/WS_Pic2.jpg" height="200px" onmouseover="src='Images/WS_Pic2_Hover.jpg'" onmouseout="src='Images/WS_Pic2.jpg'" />                        
                            </a>                          
                        </div>
                    </td>--%>
                    <td style="padding-left: 15px;">
                        <div style="text-align:center;">
                            <h3 style="padding-bottom:4px;">
                                <a href="AssistanceServices.aspx" style="font-size: 11pt;  font-weight: 700; text-decoration:none;">         
                                    ASSISTANCE SERVICES
                                </a>
                            </h3>
                            <a href="AssistanceServices.aspx">                        
                                 <img alt="" src="Images/WS_Pic3.jpg" height="200px" onmouseover="src='Images/WS_Pic3_Hover.jpg'" onmouseout="src='Images/WS_Pic3.jpg'" />                        
                            </a>                           
                        </div>
                    </td>
                    <td style="padding-left: 15px;">
                        <div style="text-align:center;">
                            <h3 style="padding-bottom:4px;">
                                <a href="Claims.aspx" style="font-size: 11pt;  font-weight: 700; text-decoration:none;">                        
                                     CLAIMS
                                </a>                            
                            </h3>
                            <a href="Claims.aspx">                        
                                 <img alt="" src="Images/WS_Pic4.jpg" height="200px" onmouseover="src='Images/WS_Pic4_Hover.jpg'" onmouseout="src='Images/WS_Pic4.jpg'" />                        
                            </a>                         
                        </div>
                    </td>
                </tr>
            </table>
        </div>                
    </div>
</asp:Content>

