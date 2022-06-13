<%@Page Language="VB" MasterPageFile="RCMD_2019.master" AutoEventWireup="false" CodeFile="Benefits.aspx.vb" Inherits="ShortTermBenefits" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%; background-image:url('Images/shortterm.png'); background-repeat:no-repeat; background-size:cover; background-position: center; ">
        <tr>
            <td style="width:60%;">

            </td>
            <td style="width:40%; text-align:center; padding-right:3%;">
                <div style="height:55%; padding: 10px 0px 70px 50px;">
                    <p class="SectionHead">Franklin & Marshall Custom Program</p>
                    <div style="text-align:left; padding-top: 26px; ">
                        <a class="secondaryA button" href="Docs/GLMN11230490_4_1_3_DOC_DCSH1011XX0711_3.20.2022.pdf" target="_blank">
                            <asp:Table class="primary button" runat="server">
                                <asp:TableRow>
                                    <asp:TableCell>
                                        Accident and Sickness Summary of Benefits<br />
                                        <span style="font-size:8pt; font-weight:bold;">Policy GLMN11230490</span>
                                    </asp:TableCell>
                                    <asp:TableCell />
                                </asp:TableRow>
                            </asp:Table>                            
                        </a>
                        <br /><br />
                        <a class="secondaryA button" href="Docs/GLMN11230490_5_0_1__Franklin & Marshall College__POL_03.20.2022.pdf" target="_blank">
                            <asp:Table class="primary button" runat="server">
                                <asp:TableRow>
                                    <asp:TableCell>
                                        Accident and Sickness Policy Document<br />
                                        <span style="font-size:8pt; font-weight:bold;">Policy GLMN11230490</span>
                                    </asp:TableCell>
                                    <asp:TableCell />
                                </asp:TableRow>
                            </asp:Table>                            
                        </a>
                          <%--<br /><br />--%>
                            <%-- <a class="secondaryA button" href="PrintIDCard.aspx" target="_blank">
                            <asp:Table class="primary button" runat="server">
                                <asp:TableRow>
                                    <asp:TableCell>
                                        Click HERE to Print your ID Card<br />
                                    </asp:TableCell>
                                    <asp:TableCell />
                                </asp:TableRow>
                            </asp:Table>                            
                        </a>--%>
                    </div>
                    <br />                    
                </div> 
                <p style="font-size: 12pt; color: black; margin-left:auto; margin-right: auto; margin-bottom:20px;">
                        This is not an optional benefit; every Franklin & Marshall College Insurance Plan participant will be covered by this plan. We recommend that all program participants maintain comprehensive health insurance while abroad.
                    </p> 
                    <p style="font-size: 12pt; color: black; margin-left:auto; margin-right: auto; margin-top:12px; padding-top:8px;">
                        As with any insurance policy, there are exclusions to the coverage which are listed in the Description of Coverage. It is important for students to read and understand the policy coverage and exclusions prior to going abroad.
                    </p>                    
            </td>
        </tr>
    </table>
    
</asp:Content>
