<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="TechEmpire___Desarrollo_y_arquitectura_web.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        navigator.geolocation.getCurrentPosition(localizame);

        function localizame(posicion) {
            const latitud = posicion.coords.latitude;
            const longitud = posicion.coords.longitude;

            //alert(`Latitud: ${latitud}, Longitud: ${longitud}`);

            //document.getElementById('mapa').src = `http://maps.google.it.maps?h1=it&ie=UTF8&Q=${latitud},${longitud}&z=17&output=embed`;

            const url = `https://www.google.com/maps?q=${latitud},${longitud}&z=17&output=embed`;
            document.getElementById('mapa').src = url;
        }
    </script>

    <style>
        #mapa{
            width:500px;
            height:500px;
        }
    </style>

    <main aria-labelledby="title">
        <h2 class="" id="title"><%: Title %>.</h2>
        <h3>Your contact page.</h3>
        <address>
            One Microsoft Way<br />
            Redmond, WA 98052-6399<br />
            <abbr title="Phone">P:</abbr>
            425.555.0100
        </address>

        <address>
            <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
            <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
        </address>

        <iframe id="mapa"></iframe>
        <script>

        </script>
    </main>
</asp:Content>
