Branching Made Easy!!!
=====

Starting a new branch for a new feature is easy as 123!

If you have changes not staged and commited, run:

```
git stash
```
This puts away your changes temporary, If you want to get them back use:

```
git stash pop
```

Change Branch with the checkout command:
-------

```
git checkout -b <my-new-branch>
```
This is shorthand for:
```
git branch <my-new-branch>
git checkout <my-new-branch>
```

Start developing on your new branch and then push the changes:
```
git push --set-upstream <remote-name> <my-new-branch>
```
This makes a new branch on the remote and pushes the changes.
Remember that the branch only exists on your maschine until you do the push!!!

Now the upstream branch is set to track the remote branch and all push, pull, fetch will work as expected.

Lost track of witch branch you where working on? Run:
```
git status
```
Want to show all branches available?
```
git branch -v
```
