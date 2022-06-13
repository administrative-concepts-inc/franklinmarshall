<%@ Page Language="VB" MasterPageFile="RCMD_2019.master" AutoEventWireup="false" CodeFile="Claims.aspx.vb" Inherits="Claims" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%; background-image:url('Images/claims.png'); background-repeat:no-repeat; background-size:cover; background-position: center; ">
        <tr>
            <td style="width:60%;">

            </td>
            <td style="width:40%; text-align:center; padding-right:8%;">
                <div style="height:50%; padding-top: 50px; padding-bottom: 50px;">
                    <p style="font-size: 12pt; color: black; margin-left:auto; margin-right: auto; padding-top:8px; margin-bottom:20px;">
                        If you incurred medical expenses during your time abroad with Franklin & Marshall and would like to file a claim for reimbursement, please select the following links for a claim form and filing details:
                    </p><br />
                    <a href="Docs/ACE generic accident-sickness student claim form FILLABLE.pdf" target="_blank">
                        <asp:Table class="primary button" runat="server">
                            <asp:TableRow>
                                <asp:TableCell>
                                    Accident & Sickness Claim Form (PDF)&nbsp;
                                </asp:TableCell>
                                <asp:TableCell />
                            </asp:TableRow>
                        </asp:Table>                            
                    </a>
                    <br />
                    <a href="Docs/ACE Trip Cancellation-Interruption Claim Form.pdf" target="_blank">
                        <asp:Table class="primary button" runat="server">
                            <asp:TableRow>
                                <asp:TableCell>
                                    Accident Only Claim Form (PDF)&nbsp;
                                </asp:TableCell>
                                <asp:TableCell />
                            </asp:TableRow>
                        </asp:Table>                            
                    </a>
                </div>                    
            </td>
        </tr>
    </table>
    <p style="font-size: 11pt; color: black; margin-left:auto; margin-right: auto; margin-top:30px;  margin-bottom:30px; padding-top:8px; width:80%;">
        Payment of medical expenses is handled differently depending on circumstances and preference of medical providers. Most commonly, you will be expected to pay the bills and then submit a claim to the Claims Administrator for reimbursement of covered expenses. If you are admitted to the hospital or have other extreme circumstances, you may be permitted (or advised) to submit the bills and a claim form to the Administrator and authorize payment of medical benefits directly to the provider.  Guarantees of payments direct to providers may be made by AXA Assistance.  These are usually for extreme circumstances and are handled on a case by case basis.<br /><br />
        Assistance Services are provided by AXA Assistance. In the event of emergency, call 1-800-243-6124 (Toll Free) or 1-202-659-7803 (Call Collect) for 24 hour assistance.<br /><br />
        Participants are advised to take a credit card abroad or maintain readily accessible emergency funds of at least US$500 with them in the event that they need to make on-site payment for any medical expenses.
    </p>
    <div style="background-color:rgb(231, 244, 253); width:100%;">

            <div style="margin-left:auto; margin-right: auto;" >
                <h3 style="margin-left:auto; margin-right: auto; text-align:center; padding:20px; font-size:22pt; color:#4f4f4f; ">
                    CLAIM SUBMISSION
                </h3>
                <table style="width:40%; margin-left:auto; margin-right: auto; text-align:left; font-size: 10pt; ">
                    <tr>
                        <td style="font-weight: bold; color:#002b54; vertical-align:top;">
                            The Claim Administrator is:
                        </td>
                        <td>
                            <span  style="font-weight: bold; color:#002b54; vertical-align:top;">Administrative Concepts, Inc. (ACI)</span><br />
                            P.O. Box 4000<br />
                            Collegeville, PA 19426-9000<br />
                            PH: <span  style="font-weight: bold; color:#002b54; vertical-align:top;">610-293-9229</span><br />
                            TF: <span  style="font-weight: bold; color:#002b54; vertical-align:top;">888-293-9229</span><br />
                            FX: <span  style="font-weight: bold; color:#002b54; vertical-align:top;">610-293-9299</span><br />
                            <a href="mailto:aciclaims@acitpa.com"style="text-decoration:none; font-weight: bold; color:#002b54; ">aciclaims@acitpa.com</a><br />
                            <a href="https://www.acitpa.com"style="text-decoration:none; font-weight: bold; color:#002b54; ">www.acitpa.com</a>
                        </td>
                    </tr>
                </table>
                <p style="width:60%; text-align:center; font-size: 10pt; color: black; margin-left:auto; margin-right: auto; margin-top:12px; padding-top:8px; font-weight: 600;">
                    Be sure to save all receipts regarding your medical expenses. The completed claim form, medical bills,<br />and any receipts for prescription charges must be submitted to: <a href="mailto:aciclaims@acitpa.com"style="text-decoration:none;">aciclaims@acitpa.com</a><br />Outside the USA & Canada: 1-610-293-9229<br />Within the US & Canada: 1-888-293-9229<br />Fax: 1-610-293-9299
                </p>
                <p style="width:60%; text-align:left; font-size: 10pt; color: black; margin-left:auto; margin-right: auto; margin-top:6px; padding-top:8px; font-weight: 400;">
                    Claims can and typically should be filed with ACI as soon as possible, to expedite the processing of the claim. Students are able to mail, fax, or scan and email their claims and receipts in from abroad for processing. Keep copies of all paperwork, in the event that anything has to be resubmitted.                    
                </p>
                <p style="width:60%; text-align:left; font-size: 10pt; color: black; margin-left:auto; margin-right: auto; margin-top:8px; font-weight: 400;">
                    The claim form must be completed by the Insured Person, as neither Franklin & Marshall nor the provider will do this for you.
                </p>
                <p style="width:60%; text-align:left; font-size: 10pt; color: black; margin-left:auto; margin-right: auto; margin-top:8px; font-weight: 400;">
                   Late claim processing is almost always due to insufficient address or an incomplete claim. Be sure to submit a complete and signed form and include your full address, so that any reimbursement due can be sent to you.
                </p>
                <h3 style="margin-left:auto; margin-right: auto; text-align:center; padding:20px 0px 8px 0px; font-size:14pt; color:#4f4f4f;">
                    CHECKING STATUS OF CLAIM
                </h3>
                <p style="width:50%; text-align:left; font-size: 10pt; color: black; margin-left:auto; margin-right: auto; margin-top:8px; font-weight: 400;">
                   ACI should be contacted with any questions concerning claims processing.<br />Additionally, ACI may be contacted via their web site for specific questions as to the status of your claim submission. 
                </p>
                <p style="width:50%; text-align:left; font-size: 10pt; color: black; margin-left:auto; margin-right: auto; margin-top:8px; font-weight: 400;">
                   To check on the status of a claim, or to otherwise contact Administrative Concepts, Inc. (ACI),<br />please use one or more of the following methods:
                </p>
                <ul style="list-style:decimal; width:45%; text-align:left; font-size: 10pt; color: black; margin:16px auto 0px auto; padding-bottom: 30px; font-weight: 600;" >
                    <li>
                        Via telephone from within the US & Canada 1-888-293-9229 or outside the USA & Canada 1-610-293-9229.
                    </li>
                    <li>
                        Via their website at <a href="https://www.acitpa.com">www.acitpa.com</a>. Click on the "ACI Claim Status" button at the bottom left, then on "insured" to check your status on-line.  You will need a member number that you can obtain by calling or emailing ACI.
                    </li>
                    <li>
                        Via email at <a href="mailto:aciclaims@acitpa.com"style="text-decoration:none;">aciclaims@acitpa.com</a>
                    </li>
                </ul>
            </div>            
        </div>
</asp:Content>
