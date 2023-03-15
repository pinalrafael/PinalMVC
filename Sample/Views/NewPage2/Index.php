<h1>NewPage Index</h1>
<?php echo $pmvc_Model->msg; ?>
<br>
<a href="<?php echo $pmvc_root; ?>NewPage2/Create">Create</a>
<table>
	<tr>
		<th>ID</th>
		<th>Name</th>
		<th>Options</th>
	</tr>
	<tr>
		<td>1</td>
		<td>Name 1</td>
		<td><a href="<?php echo $pmvc_root; ?>NewPage2/Update/1">Update</a> - <a href="<?php echo $pmvc_root; ?>NewPage/Delete2/1">Delete</a></td>
	</tr>
	<tr>
		<td>2</td>
		<td>Name 2</td>
		<td><a href="<?php echo $pmvc_root; ?>NewPage2/Update/2">Update</a> - <a href="<?php echo $pmvc_root; ?>NewPage/Delete2/2">Delete</a></td>
	</tr>
</table>