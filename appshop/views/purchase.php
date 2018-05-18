<?php
/* 
 * purchase.php
 * @author Brian
 */
include 'header.php';
include_once '../libs/puchases.php';
?>

<table>
    <form action='../libs/sales.php' method='POST'> 
     <?php $app->sales(); ?>
    </form>
</table>
 
<?php
echo "<br><br>";
include "footer.php";
?>

