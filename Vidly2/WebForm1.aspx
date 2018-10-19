<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Vidly2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-3.3.1.min.js"></script>


</head>
<body>
    <form id="form1" runat="server">
        
    <div>

    <p>Please click on the button control.</p>

    <button type="submit" class="id-button">Submit</button>
    <div id="output-box"></div>
        <br /><br /><br />

   <%--     <a href="#" class="myLink disabled">My link</a>--%>

        <script type="text/javascript">

            $(document).ready(function () {

                //document.querySelector("#id-button").addEventListener("click", function (event) {
                //    document.getElementById("output-box").innerHTML += "Sorry! <code>preventDefault()</code> won't let you check this!<br>";
                //    event.preventDefault();
                //}, false);

                $(document).on('click', '.id-button', function () {
                    document.getElementById("output-box").innerHTML += "Sorry! <code>preventDefault()</code> won't let you submit this!<br>";
                    event.preventDefault();
                });

                $(".myLink").on('click', function (event) {
                    if ($(this).hasClass('disabled')) {
                        event.preventDefault();
                    $(this).addClass().html("<span>Hello</span>")

                        // return false; // Use when no action should be performed
                    } else {
                        // Handle event

                    }
                });

            });
        </script>
    </div>
    </form>
</body>
</html>
