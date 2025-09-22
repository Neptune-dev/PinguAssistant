<?php

    require_once('includes/config.php');

    function openDB() {
        $pdo = new PDO('mysql:host='.$GLOBALS['addr'].';dbname='.$GLOBALS['dbName'], $GLOBALS['MySQLusername'], $GLOBALS['MySQLpwd']);
        $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
        return $pdo;
    }

    function checkAdmin () {
        if ($_SESSION["user"]["isAdmin"] != 1) {
        header("Location: /401");
        exit();
        }
    }

?>