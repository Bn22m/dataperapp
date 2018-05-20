<?php

/* 
 * view.php
 * @author Brian
 */
include 'header.php';
include_once '../libs/puchases.php';

?>
<a href="../index.php">Exit</a>
<a href="../libs/transactions.php">View transactions </a>
<hr><br>
<table>
    <?php
      $app->sales();
    ?>
</table>


<?php
echo "<br><br>";
include "footer.php";
?>
