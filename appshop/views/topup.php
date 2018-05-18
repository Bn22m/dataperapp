<?php

/* 
 * topup.php
 * @author Brian
 */
include 'header.php'

?>
<table>
    <form action='../libs/topups.php' method='POST'>
    <tr><td>User:</td>
        <td><input name="userp" type="" value="<?php echo " ".$_SESSION['userid'].""; ?>" min="0" readonly="true"/></td>
    </tr>
    <tr><td>Topup:</td>
        <td><input name="topup" type="number" value="200" min="100"/></td>
    </tr>
    <tr>
        <td><input type="submit" name="btntop" value="Top Up"/></td>
    </tr>
    </form>
</table>




<?php
echo "<br><br>";
include "footer.php";
?>
