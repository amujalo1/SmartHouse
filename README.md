# Smart House Project

## Overview
This repository contains the source code and documentation for the Smart House project, developed as part of the Skyline Talent Program. The project focuses on creating a modular and scalable system for managing smart homes, including rooms, devices, and their hierarchical relationships. The system is designed to simulate a smart home environment where users can interact with and manage various components programmatically.

The project has gone through multiple iterations, with the latest version (V4) being the most stable and feature-rich. Below is a detailed explanation of the repository structure, branches, and key features.

## Repository Structure

### Branches

- **main**  
  The main branch contains the latest stable version of the project (V4). This branch is production-ready and includes all the latest features, optimizations, and bug fixes.

- **develop**  
  The develop branch is used for ongoing development. It mirrors the main branch but is used for testing new features and improvements before they are merged into main.

- **docs**  
  The docs branch is dedicated to documentation. It includes detailed commit histories, explanations of changes, and class diagrams to help understand the project's evolution and structure.

- **SmartHouse/V2**  
  This branch contains an older version of the project (V2). It represents the state of the project before the major refactoring that led to V3. It is kept for reference and comparison purposes.

- **SmartHouse/V3**  
  This branch is identical to the main branch and contains the latest version of the project (V3). It reflects the final state of the project after all refactoring and optimizations.

- **SmartHouse/V4**
  This branch contains the latest version of the project (V4). It introduces power consumption tracking, deep component removal, and improved hierarchical updates.

- **feat/add-MoveTo**  
  This branch was created to implement the MoveTo functionality, which allows moving devices (nodes) between rooms or objects in the hierarchy. It was later merged into the develop and main branches.

- **feat/unit-test**  
  This branch was used to add 40 xUnit tests to the project. These tests cover various functionalities, including hierarchy management, device movement, and cycle prevention. The tests ensure the stability and reliability of the system.
- **feat/power-monitoring**
  This branch was created to introduce power consumption tracking and deep component removal.
  - Added powerConsumption tracking to components.
  - Implemented DeepRemove for removing components from the top of the hierarchy.
  - Ensured proper power consumption updates when adding or removing components.

- **bugfix/hierarchical-cycle-prevention**  
  This branch was created to fix a critical issue where nodes could form infinite loops in the hierarchy. The issue was resolved by implementing a mechanism to detect and prevent cycles during node addition. More details about this issue can be found in the Issues section.

## Key Features
### Version V4 Highlights

- **Power Consumption Tracking:** Implemented `powerConsumption` tracking across components, ensuring accurate energy usage calculations.  
- **Deep Component Removal (`DeepRemove` and `DeepRemoveID`):** Added a method to remove components from the top of the hierarchy while properly updating dependencies.  
- **Hierarchy Update Fix:** Ensured that power consumption updates correctly when adding or removing components.  
- **Additional Unit Tests:** Added 2 new xUnit tests to verify power consumption calculations and component removal logic.  
- **Refined Class Structure:** Improved hierarchy management and data integrity across the system.  
- **Optimized UI:** Further enhanced console-based interaction for better readability and usability.  

### Version V3 Highlights

- **Unified Class Structure:** The `Objekat` class now serves as a universal node in the hierarchy, replacing the previous `SmartHouse` and `Room` classes. This simplifies the code and improves flexibility.

- **Hierarchy Management:** The system enforces logical rules for object relationships (e.g., a house can contain floors, floors can contain rooms, and rooms can contain devices).

- **Cycle Prevention:** A mechanism was implemented to detect and prevent infinite loops in the hierarchy.

- **MoveTo Functionality:** Devices can be moved between rooms or objects dynamically.

- **Unit Tests:** 40 xUnit tests were added to verify the correctness of the system.

- **Improved UI:** The console interface was optimized for better user interaction and data presentation.

## Issues and Solutions

### Issue #1: Are Specialized Room Classes Necessary?

- **Description:** The need for specialized room classes (e.g., `SpavaćaSoba`, `DnevnaSoba`) was questioned. These classes inherit from `Objekat` but do not provide additional functionality. The decision was made to keep them for potential future use, while the core functionality is handled by the `Objekat` class.
- **Solution:** Specialized room classes were retained, but the primary focus shifted to the `Objekat` class, which now manages the hierarchy and relationships between objects.

### Issue #2: Validation of Hierarchy After Merging SmartHouse and Room

- **Description:** After merging the `SmartHouse` and `Room` classes into `Objekat`, there was no mechanism to prevent invalid relationships (e.g., adding a house inside a room). This could lead to logical inconsistencies in the hierarchy.
- **Solution:** A validation mechanism was implemented in the `bugfix/hierarchical-cycle-prevention` branch. It ensures that:
  - An object cannot be added to itself or its descendants.
  - Logical rules are enforced (e.g., a house can only contain floors or devices, a floor can only contain rooms or devices, and a room can only contain devices).


## How to Use

1. Clone the repository:
    ```bash
    git clone https://github.com/amujalo1/SmartHouse.git
    ```

2. Switch to the main branch for the latest stable version:
    ```bash
    git checkout main
    ```

3. Explore the docs branch for detailed documentation and commit history.
   ```bash
    git checkout docs
    ```

5. Run the project using your preferred IDE or build tool.

## Conclusion
The Smart House project demonstrates the evolution of a modular and scalable system for managing smart home environments. Through iterative development, refactoring, and testing, the project has achieved a stable and efficient architecture. The latest version (V4) is ready for production use, with additional features and improvements planned for future updates.

For more details, refer to the documentation in the `docs` branch or explore the commit history. Contributions and feedback are welcome! 🚀
