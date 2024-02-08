## Introduction
This Unity custom package provides a simple notification system for both macOS and Windows platforms using native UI elements.

## Features
- **Cross-platform:** Supports both macOS and Windows platforms.
- **Native UI:** Utilizes native UI elements for displaying notifications.
- **Customizable:** Easily customizable with parameters for message and title.

## Usage
1. **Import the Package:**
   - You can install it with **Package Manager** > **+** > **Add package from git URL...**
  
     ```
     https://github.com/sangwookyoo/unity-native-notification.git
     ```

2. **Show Notification:**
   - Call the 'Notification.Show(string message, string title)' method with the desired message and title to display a notification. The 'Notification' class automatically handles platform-specific implementations for both macOS and Windows.
  
      ```csharp
      using UnityEngine;
      using NativeAlert.Tools;

      public class Example : MonoBehaviour
      {
         void Start()
         {
            // Display a notification with a message and title
            Notification.Show("Hello, World!", "Notification Title");
         }
      }
      ```

## Note
This package is designed for standalone builds and editor testing on macOS and Windows platforms. It may not work as expected on other platforms.

## Contribution
Contributions are welcome! If you find any issues or have suggestions for improvements, feel free to submit a pull request or open an issue on GitHub.

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
