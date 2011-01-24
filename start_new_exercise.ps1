param($message)

function get_commit_message($passed_in_at_command_line)
{
  $commit_message = $passed_in_at_command_line

  if ($commit_message -eq $null)
  {
    write-host "Please enter a commit message (leave blank to exit):"
    $commit_message = read-host
  }
  return $commit_message
}

function format_time_as_new_branch_name
{
  "$($now.year)$($now.month)$($now.day)$($now.hour)$($now.minute)"
}

function get_latest_on_new_branch($branch_name)
{
  git add -A
  git commit -m "Committing"
  git checkout master
  git checkout -b format_time_as_new_branch_name
  git pull jp master
}

$new_branch_name = format_time_as_new_branch_name
get_latest_on_new_branch($new_branch_name)
echo "new branch name:$new_branch_name message:$commit_message"
