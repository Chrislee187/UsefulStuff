set-alias -name npp -value 'C:\Program Files (x86)\Notepad++\notepad++.exe' -scope Global
set-alias -name subl -value 'C:\Program Files\Sublime Text 2\sublime_text.exe' -scope Global
set-alias -name mine -value 'C:\Program Files (x86)\JetBrains\RubyMine 2016.2.3\bin\RUBYMINE.BAT' -scope Global
set-alias -name ws -value 'C:\Program Files (x86)\JetBrains\WebStorm 2016.2.3\bin\WebStorm.exe' -scope Global
set-alias -name code -value 'C:\Program Files (x86)\Microsoft VS Code\Code.exe' -scope Global

function gst { & git status }
function gpu { & git push }
function gpr { & git pull --rebase }
function gco([string] $msg) { 
	& git commit -m "$msg" 
}
function gaa { & git add -A }

function ep 
{
	&'C:\Program Files (x86)\Notepad++\notepad++.exe' $profile
}
function rlp 
{
	. $profile
}

function src([string] $folder)
{
	&cd \src\$folder
}

function size([string] $startFolder)
{
	$colItems = (Get-ChildItem $startFolder | Measure-Object -property length -sum)
	"$startFolder -- " + "{0:N2}" -f ($colItems.sum / 1MB) + " MB"

	$colItems = (Get-ChildItem $startFolder -recurse | Where-Object {$_.PSIsContainer -eq $True} | Sort-Object)
	foreach ($i in $colItems)
	{
		$subFolderItems = (Get-ChildItem $i.FullName | Measure-Object -property length -sum)
		$i.FullName + " -- " + "{0:N2}" -f ($subFolderItems.sum )
	}

}