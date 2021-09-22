# Git Workflow
## Create a new branch
When you are making a new feature, make a branch to keep all your changes on. Once you are done, this branch will be merged with main via a pull request.

`git checkout -b <branch_name>`

Try to keep branch names descriptive of your work, and consider including your name, such as:

`git checkout -b rwetzler_contributing_doc`

## Pull in changes from main
Before you start coding, and periodically whenever a PR is merged, make sure to pull in the new changes from main. Otherwise your branch will be far behind main when you try to make a PR.

`git pull origin main`

This pulls in changes from the remote main branch and merges it with your local checked-out branch.

Note: If the new changes to main conflict with your changes, you will get a merge conflict. Use `git status` to see which files have a conflict, and go to the files in visual studio to fix them (the conflicts should be marked, and visual studio should have a menu to help with this).

## Stage your changes
After you are done making your changes, you need to stage them to your commit. To see which files have been changed, use the command:

`git status`

It's important to only stage files that you intended to be included in the commit, so it's a good practice to stage files one-by-one using:

`git add <file>`

With <file> being the exact filepath that `git status` provided.

Once you have staged all your files, run `git status` again to double check that they are all staged.

## Create your commit
After staging your files, create a commit using the following:

`git commit -m "Descriptive commit message here"`

## Push your changed to your remote branch
Time to push your changes to your remote branch. Use the following command:

`git push`

If this is your first time pushing changes with this branch, you will be prompted to create the branch remotely using the following command:

`git push --set-upstream origin <branch_name>`

If you get this prompt, just copy and paste it into your terminal.

## Make a PR on github
Go to the pull request tab on github and make a pull request for your branch into main.

# Other stuff
## Viewing all your branches
`git branch`

## Switching to a branch that already exists locally
`git checkout <branch_name>`
Also make sure to pull using git 

## Reverting an unstaged files
There's a lot of ways to undo changes, but if you want to revert your changes to a file, use:

`git checkout -- <file>`

## See what changes were made to a file

`git diff <file>`