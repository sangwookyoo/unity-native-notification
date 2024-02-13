## Introduction
This Unity custom package provides a simple notification system for both macOS and Windows platforms using native UI elements.
- macOS
  
  <img width="372" alt="macOS" src="https://github.com/sangwookyoo/unity-native-notification/assets/61134850/820077cf-ebaa-46d6-ad39-c46850745146">

- Windows
  
  <img width="372" alt="Windows" src="https://github.com/sangwookyoo/unity-native-notification/assets/61134850/95488ac1-f537-4de7-8f9d-88fd34751eec">

## Features
- **Cross-platform:** Supports both macOS and Windows platforms.
- **Native UI:** Utilizes native UI elements for displaying notifications.
- **Customizable:** Easily customizable with parameters for title and message.

## Installation
1. **Changing API Compatibility Level:**
    - **Project Settings** > **Player** > **Other Settings** > **Configuration** > **Api Compatibility Level**

      `.NET Framework`

2. **Import the Package:**
    - **Package Manager** > **+** > **Add package from git URL...**

      ```
      https://github.com/sangwookyoo/unity-native-notification.git
      ```

3. **Show Notification:**
    - Call the 'Notification.Show(string title, string message)' method with the desired title and message to display a notification. The 'Notification' class automatically handles platform-specific implementations for both macOS and Windows.

       ```csharp
       using UnityEngine;
       using NativeAlert.Tools;
 
       public class Example : MonoBehaviour
       {
          void Start()
          {
             // Display a notification with a title and message
             Notification.Show("Notification Title", "Hello, World!");
 
             // Windows-only: You can also add .ico icon file path for your notifications.
             Notification.Show("Notification Title", "Hello, World!", Path.Combine(Application.streamingAssetsPath, "AppIcon.ico"));
          }
       }
       ```

## Note
This package is designed for standalone builds and editor testing on macOS and Windows platforms. It may not work as expected on other platforms.

## Contribution
Contributions are welcome! If you find any issues or have suggestions for improvements, feel free to submit a pull request or open an issue on GitHub.

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
