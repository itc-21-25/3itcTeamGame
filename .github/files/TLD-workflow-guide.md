# Contributing Guide for Team Leaders (TLDs)

## Overview

As a Team Leader (TLD), your role involves overseeing your team's contributions to their respective branches and managing the integration of these contributions into the `integration` branch. This guide will help you maintain consistency and efficiency in the workflow.

## Working on Team Branches

### Committing and Pushing to Team Branches

- Your team members will directly commit and push their changes to the team branch (e.g., `PRG1`).
- Team branches are unprotected for team members. They do not need to create pull requests for their commits.

### Issue Tracking and Review Process

- When a team member completes a task, they should move the related issue in the GitHub Projects (planner) to the **Code Review** column.
- As a TLD, review the committed code in your team's branch. Provide feedback or request changes as necessary.

## Creating Pull Requests to Integration Branch

### Initiating Pull Requests

- Once you approve the changes in your team's branch, create a pull request to merge these changes into the protected `integration` branch.
- Follow the naming convention for pull requests:
  - For a new feature: `team-name/feature/ID-nameOfFunction`
  - For a bug fix: `team-name/fix/ID-nameOfFunction`

### Assigning Pull Requests

- After creating the pull request, assign `FoodWithoutTaste` to the pull request for further review.

### Updating Project Tracker

- Move the associated issue in the GitHub Projects (planner) to the **Spojování** column.
- Add the label `Spojovani` to the issue.

## Updating Your Team Branch

### Merging from `dev`

- If you need to update your team branch with the latest changes from the `dev` branch, you can merge or rebase from `dev` into your team branch.

## Branch Structure Overview

Our project utilizes a specific branch structure to effectively organize and manage the development process. Understanding the role of each branch will help you contribute appropriately and follow the project workflow.

![image](https://github.com/itc-21-25/3itcTeamGame/assets/102674544/c78281ac-5fc9-47bc-a669-c663b38c2e3f)

### Main Branches

1. **`main` Branch:**
   - Contains the most stable and tested version of our game.
   - Code merged into `main` represents production-ready stages of development.
   - Direct commits to this branch are restricted.

2. **`dev` Branch:**
   - Where the latest working version of our game resides.
   - A step ahead of `main` with stable features and fixes in progress.
   - Changes are merged into `dev` from `integration` after thorough review and testing.

3. **`integration` Branch:**
   - Serves as a staging area for combining features and updates from different team branches.
   - Crucial for ensuring all pieces of the game work together.
   - TLDs are responsible for creating pull requests to `integration`.

### Team Branches

- **Team-Specific Branches (e.g., `PRG1`):**
  - Dedicated to specific teams working on aspects of the game.
  - Team members commit and push changes to these branches.
  - Managed by respective TLDs who review commits and manage merging into `integration`.

### TLDs: Merging and Updating Branches

- **Merging to `integration`:**
  - TLDs merge changes from their team's branch to `integration` when features are ready for integration testing.

- **Updating from `dev`:**
  - TLDs update their team's branch from `dev` to work with the latest stable and reliable codebase.
