<h1>APICli Index</h1>
<br>
<a href="<?php echo $pmvc_root; ?>APICli/Create">Create</a>
<table>
	<tr>
		<th>ID</th>
		<th>Name</th>
		<th>Options</th>
	</tr>
	<?php
	foreach ($pmvc_Model->list as $Model ) {  
	?>
	<tr>
		<td><?php echo $Model["id"]; ?></td>
		<td><?php echo utf8_decode($Model["name"]); ?></td>
		<td><a href="<?php echo $pmvc_root; ?>APICli/Update/<?php echo $Model["id"]; ?>">Update</a> - <a href="<?php echo $pmvc_root; ?>APICli/Delete/<?php echo $Model["id"]; ?>">Delete</a></td>
	</tr>
	<?php
	}
	?>
</table>