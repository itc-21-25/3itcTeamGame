# Contributing Guide for Team Members

## Overview

As a team member, your contributions are vital to the success of the project. This guide will help you understand your role in the development process, how to commit changes, and how to effectively use issue tracking.

## Committing and Pushing to Your Team Branch

### Working on Features/Bugs

- Work on assigned tasks and features as per the project's GitHub Projects (planner) and issues assigned to you.
- Ensure you're working on the correct team branch (e.g., `PRG1` for PRG1 team).

### Committing Your Changes

- When you complete a task or reach a significant checkpoint, commit your changes.
- Use the following format for commit messages, including the related issue ID:
  - New feature: `feat: ID/description`
  - Bug fix: `fix: ID/description`
  - Code refactoring: `refactor: ID/description`
  - Performance optimization: `perf: ID/description`
- Provide a clear and concise description in the Summary. Use the Description for detailed explanations if needed.

### Pushing Changes

- Push your commits to the appropriate team branch.
- There's no need to create pull requests for your own team branch, as it's unprotected for team members.

## Issue Tracking and Progress

### Moving Issues in Projects (Planner)

- After completing a task and pushing your changes, move the related issue in the GitHub Projects (planner) to the **Code Review** column.
- This signals to your Team Leader (TLD) that your task is ready for review.

### Responding to Feedback

- If your TLD requests changes or additional work, make the necessary modifications and push the updates.
- Keep communication open with your TLD for any clarifications or assistance.

## Branch Structure Overview

Our project utilizes a specific branch structure to effectively organize and manage the development process. Understanding the role of each branch will help you contribute appropriately and follow the project workflow.

![image](https://github.com/itc-21-25/3itcTeamGame/assets/102674544/9efabd19-8afa-4fdb-b6ad-5379cdc141f9)


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
   - Only Team Leaders (TLDs) can create pull requests to merge into `integration`.

### Team Branches

- **Team-Specific Branches (e.g., `PRG1`):**
  - Dedicated to specific teams working on aspects of the game.
  - Team members commit and push changes to these branches.
  - Managed by respective TLDs who review commits and manage merging into `integration`.
