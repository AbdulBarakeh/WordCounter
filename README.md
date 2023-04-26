# WordCounter

## To run this project
To be able to run this project you need a directory structure that resembels the following:

- ./DirectoryWithProjectExecuteable
  - Resources
    - Exclude
    - Input
      - Source1.txt
      - Source2.txt
      - Source3.txt
      - Source4.txt
      - Exclude.txt
    - Output

Let the **Exclude** and **Output** folders stay empty, but place the desired files to sort into the input folder. Lastly, add a file that contains a list of words to be excluded.

## Memoryfootprint
By attempting to use streams to read and write data, I've improved the efficiency and memoryfootprint. The reason behind this is that streams don't store the whole file's data in memory, it does it in batches. This can be compared to reading a file with the **File** class, where the file and all its contents are saved in memory. Saving all the file's data to memory can slowly become a costly process the bigger the file gets, potentially getting closer to an OutOfMemoryException. 
However due to timelimits it wasn't possible to apply this principle everywhere, and the code is in someplaces saving and processing data in memory, which can become a problem with larger datasets.

## Running on multicore CPU
By attempting to make the code asynchronus it's possible to utilize more of the CPU's resources, by enabling the code to run in parallel, thereby gaining an improved efficiency.

## Possible improvements
Make the project run in the exact same way but remove the **FILE_GENERAL.txt** file that contains all the words from all the other sourcefiles. The closer the number of files get to infinity the closer the file size of **FILE_GENERAL.txt** gets to infinity. This can possibly give MemoryExceptions and in general lower the efficiency of the program.

## Project structure
The below image shows the different components used to build the WordCounter software. 
Some of the thoughts behind the chosen structure:
* Implement interface to create a more loose coupling, and enable easier maintainability
* Create components with only a single responsibility
* Dependency injection on method-level, enables the code to be extended without being modified due to the dependency being on an interface and not on a specific class.
![WordCounter_Diagram](https://user-images.githubusercontent.com/44008172/234650546-ecdbcf16-5e28-410a-b09e-49f7ed1521fa.png)

## Iterations/Process
The software were built in iterations (listed below). This helped keep me on track with the requirements. For every iteration I would write some test that helped me ensure that the current state of the software were usable as expected. This also helped me uphold a good code structure and made it easier to implement the functionality within the components. <u>***OBS. Keep in mind that not all tests run succesfully, that is on purpose. Unsuccesfull tests were part of the component testing process and have not been updated. These are kept transparency reasons***</u>

1. Read one file, and count all words in one file.
2. Split wordcount into multiple files.
3. Add exclusion functionality.
4. Read from multiple sourcefiles.

