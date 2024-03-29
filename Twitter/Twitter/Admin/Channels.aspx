﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Channels.aspx.cs" Inherits="Twitter.Admin.Channels" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="main-content-heading">Channels</h1>

    <asp:GridView runat="server" ID="GridViewMyChannels" OnDataBinding="GridViewChannels_DataBinding"
        AllowPaging="true" PageSize="3" SelectMethod="GridViewChannels_GetData"
        AllowSorting="true" AutoGenerateColumns="false" DataKeyNames="ChannelId"
        ItemType="Twitter.Models.Channel" CssClass="table"
        AutoGenerateEditButton="true" UpdateMethod="GridViewMyChannels_UpdateItem"
        AutoGenerateDeleteButton="true" DeleteMethod="GridViewMyChannels_DeleteItem"
        EmptyDataText="You have no channels.">
        <Columns>
            <asp:TemplateField HeaderText="Creator">
                <ItemTemplate>
                    <asp:LinkButton runat="server" Text="<%#: Item.AspNetUser.UserName %>"
                         PostBackUrl='<%# String.Format("~/UserProfile.aspx?username={0}", Eval("AspNetUser.UserName").ToString()) %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Channel Name" SortExpression="Name">
                <ItemTemplate>
                    <asp:HyperLink Text="<%#:Item.Name%>" runat="server"
                        NavigateUrl='<%# String.Format("Messages.aspx?channelId={0}", Eval("ChannelId").ToString()) %>'
                        DataNavigateUrlFields="ChannelId" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox runat="server" ID="TextBoxEditChannel" Text="<%#: BindItem.Name %>" />
                </EditItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
    <asp:LinkButton CssClass="btn btn-primary" PostBackUrl="~/Channels/CreateChannel.aspx" Text="Create channel" runat="server" />
    <asp:LinkButton CssClass="btn btn-primary" PostBackUrl="~/Messages/CreateMessage.aspx" Text="Add New Message" runat="server" />
</asp:Content>
