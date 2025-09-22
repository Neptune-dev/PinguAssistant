<?php
ob_start();
?>

<?php
session_start();
?>

<h1>Coucou</h1>

<?php
$title = "Pingu";
$content = ob_get_clean();
require('views/base.php');
?>