<?php
    $servername = "localhost";
    $username = "zp9039_spoodiman";
    $password = "AAaa00";
    $dbname = "zp9039_spoodimal";

    $con = new mysqli($servername, $username, $password, $dbname);
    $con->query("set names utf8");
?>