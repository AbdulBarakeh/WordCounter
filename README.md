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
By attempting to make the code asynchronus it's possible to utilize more of the CPU's resources, and enables the code to run in parallel, thereby gaining an improved efficiency.



