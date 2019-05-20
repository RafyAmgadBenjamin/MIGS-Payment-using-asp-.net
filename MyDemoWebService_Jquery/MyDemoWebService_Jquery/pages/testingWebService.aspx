<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testingWebService.aspx.cs" Inherits="MyDemoWebService_Jquery.pages.testingWebService" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="/Scripts/jquery-1.10.2.min.js" type="text/javascript"></script>
<script type="text/javascript">

        $(document).ready(function(){
            $("#Button1").click(function() {

                $.ajax({
                    type: "POST",
                    url: "/Services/DateWebService.asmx/GetDateTime",
                    data: "{}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg)
                    {
                        $("#output").text(msg.d);
                    }
                });

            });
        });

</script>
</head>
<body>
    <form id="form1" runat="server">
    <input id="Button1" type="button" value="Get Date and Time" />
    <br />
    <br />
    <span id="output" />
</form>
</body>
</html>
