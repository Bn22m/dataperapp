<?php
//session_start();

/* 
 * index.php
 * @author Brian
 */

include 'header.php';
?>
<a href="../index.php">Log Out</a>
<?php echo "<br>".$_SESSION["userid"]."<br>";?>
<hr><br>
<section id="more"></section>
<div>
    <ul>
        <li><a href="#">Welcome</a></li>
        <li><a href="topup.php">Top up my account</a></li>
        <li><a href="purchase.php">Purchases</a></li
        <li><a href="#"><img src="../shopping.png"/></a></li>
        <li><a href="view.php">View specials </a></li>
        <li><a href="../libs/transactions.php">View more </a></li>
    </ul>
</div>
<section id="info"></section>



<?php
echo " ".$_SESSION['userid']." ";
echo "<br>  <br>";
include "footer.php";
?>
       


