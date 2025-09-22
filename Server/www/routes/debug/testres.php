<?php

if ($_SERVER["REQUEST_METHOD"] == "GET")
{
    $data =
    [
        'test' => 'oui',
        'age' => $_GET["nom"]
    ];
    
    http_response_code(200);
    header('Content-Type: application/json; charset=utf-8');
    echo json_encode($data);
}

?>