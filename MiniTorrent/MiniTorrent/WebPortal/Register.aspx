<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MiniTorrent.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        .bd-placeholder-img {
            font-size: 1.125rem;
            text-anchor: middle;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
        }

        @media (min-width: 768px) {
            .bd-placeholder-img-lg {
                font-size: 3.5rem;
            }
        }
    </style>
</head>
<body>

    <!-- #include file ="_Layout.html" -->

    <form id="form1" runat="server" action="">
        <div class="text-center mb-4">
            <img class="mb-4" src="../Images/torrentLogo.jpeg" alt="" width="25%">
            <h1 class="h3 mb-3 font-weight-normal">Register to our Torrent !!</h1>
        </div>

        <div class="container">
        <div class="form-label-group">
            <label for="inputusername">Username</label>
            <input type="text" id="inputusername" class="form-control" placeholder="Username" required autofocus>
        </div>

        <div class="form-label-group">
            <label for="inputPassword">Password</label>
            <input type="password" id="inputPassword" class="form-control" placeholder="Password" required>
        </div>

        <div class="form-label-group">
            <label for="ip">IP</label>
            <asp:Label runat="server" type="text" ID="ip" class="form-control"></asp:Label>
        </div>

        <div class="form-label-group">
           <label for="port">Port</label>
            <asp:Label runat="server" type="text" ID="port" class="form-control"></asp:Label>


        </div>



        <button class="btn btn-lg btn-primary btn-block" type="submit">Join now !</button>
        <p class="mt-5 mb-3 text-muted text-center">&copy; 2017-2019</p>


            </div>
    </form>

    <script>
        $("#form1").submit(function (e) {

         
            // username and password
            var password = $('#inputPassword').val();
            var username = $('#inputusername').val();

            var ip = $('#ip').text();
            var port = $('#port').text();

            console.log(password, username, ip, port);

           

            var form = $(this);
            var url = "/api/Admins/register";
            var mydata =
                { "password": password, "username": username, "IP": ip, "port": port };

        
            $.ajax({
                type: "POST",
                url: url,
                data: mydata, // serializes the form's elements.
                success: function (data) {
                    alert("Register Successfully ,please upload to share folder !")
                    //console.log(data); // show response from the php script.
                }
            });

            e.preventDefault(); // avoid to execute the actual submit of the form.
        });


    </script>

</body>
</html>
