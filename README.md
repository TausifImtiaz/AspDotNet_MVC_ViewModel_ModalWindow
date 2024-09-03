# AspDotNet_MVC_ViewModel_ModalWindow

## Overview

This project is a demonstration of an ASP.NET MVC application implementing a Master-Details pattern using ViewModels and CRUD operations with the help of modal windows. The application showcases how to manage and interact with data in a user-friendly way, utilizing modal windows for CRUD operations.

## Features

- **Master-Details View:** Display a list of items (master) and their associated details in a user-friendly format.
- **CRUD Operations:** Create, Read, Update, and Delete operations for managing the items.
- **Modal Windows:** Use modal pop-ups for creating and editing items, enhancing the user experience by keeping users on the same page.

## Technologies Used

- ASP.NET MVC Framework
- C#
- HTML/CSS
- JavaScript/jQuery
- Bootstrap (for modal dialogs and styling)

## Project Structure

- **Models:** Contains the classes that represent the data structure.
- **ViewModels:** Includes classes that provide data for the views, facilitating the Master-Details pattern.
- **Controllers:** Manages the application's flow and interactions between the model and views.
- **Views:** Contains the Razor view files that render the UI, including the main views and partial views used in modals.

## Getting Started

### Prerequisites

- .NET Framework 4.7.2 or higher
- Visual Studio 2019 or later
- SQL Server (for database operations)

### Installation

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/TausifImtiaz/AspDotNet_MVC_ViewModel_ModalWindow.git
   ```

2. **Open the Solution:**
   Open the solution file (`.sln`) in Visual Studio.

3. **Restore NuGet Packages:**
   Ensure all required NuGet packages are restored. You can do this by building the solution or using the NuGet Package Manager.

4. **Database Configuration:**
   - Update the connection string in `Web.config` to match your SQL Server instance.
   - Run the database migration scripts if applicable.

5. **Run the Application:**
   Press `F5` or click on the "Start" button in Visual Studio to build and run the application.

## Usage

1. **Accessing the Application:**
   Navigate to the application URL provided by Visual Studio after running the project.

2. **Interacting with the Master-Details View:**
   - The main page will display a list of items.
   - Click on an item to view its details.

3. **CRUD Operations with Modal Windows:**
   - **Create:** Click the "Add New" button to open a modal window for adding a new item.
   - **Edit:** Click the "Edit" button next to an item to open a modal for editing.
   - **Delete:** Click the "Delete" button next to an item to remove it from the list. A confirmation dialog will appear.

## Code Example

### Controller Example

```csharp
public class ItemsController : Controller
{
    // GET: Items
    public ActionResult Index()
    {
        var model = new ItemViewModel
        {
            Items = _itemService.GetAllItems()
        };
        return View(model);
    }

    // POST: Items/Create
    [HttpPost]
    public ActionResult Create(ItemViewModel model)
    {
        if (ModelState.IsValid)
        {
            _itemService.AddItem(model.Item);
            return RedirectToAction("Index");
        }
        return View(model);
    }

    // POST: Items/Edit
    [HttpPost]
    public ActionResult Edit(ItemViewModel model)
    {
        if (ModelState.IsValid)
        {
            _itemService.UpdateItem(model.Item);
            return RedirectToAction("Index");
        }
        return View(model);
    }

    // POST: Items/Delete
    [HttpPost]
    public ActionResult Delete(int id)
    {
        _itemService.DeleteItem(id);
        return RedirectToAction("Index");
    }
}
```

## Contributing

Contributions are welcome! Please follow these guidelines:
- Fork the repository.
- Create a feature branch.
- Commit your changes.
- Push to the branch.
- Create a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgements

- ASP.NET MVC documentation and tutorials
- Bootstrap for UI components

## Contact

For any questions or issues, please contact [Tausif Imtiaz](mailto:tausifimtiaz@gmail.com).

---

Thank you for using and contributing to this project!

