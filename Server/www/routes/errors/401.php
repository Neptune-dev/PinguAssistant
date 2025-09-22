<?php
ob_start();
?>

<h1>401 Unauthorized</h1>

<p>Une authentification est nécessaire pour accéder à la ressource.</p>

<?php
$title = '401';
$content = ob_get_clean();
require('views/base.php');
?>