import tensorflow as tf
import argparse
import numpy as np
from PIL import Image

# Define command-line arguments
parser = argparse.ArgumentParser(description='Load a TensorFlow model and make a prediction.')
parser.add_argument('--model_path', type=str, required=True,
                    help='Path to the TensorFlow .h5 model file')
parser.add_argument('--input', type=str, nargs='+', required=True,
                    help='Input to the model, separated by spaces')

# Parse command-line arguments
args = parser.parse_args()
print(args.input[0])

# Load the TensorFlow model from .h5 file
model = tf.keras.models.load_model(args.model_path)

# Load image using PIL
image = Image.open(args.input[0])

# Convert image to NumPy array
image_array = tf.keras.preprocessing.image.img_to_array(image)

# Normalize input data between 0 and 1
image_normalized = (image_array - image_array.min()) / (image_array.max() - image_array.min())

flatten_image_array_shape = image_normalized[None, ...]
print(flatten_image_array_shape.shape)
#flatten_image_array_shape = np.array(np.expand_dims(image_array, axis=(0)))
#print(flatten_image_array_shape.shape)
#flatten_image_array_shape = np.array(flatten(image_array.shape))

#image_array = image_array.reshape(1, flatten_image_array_shape[0], flatten_image_array_shape[1], flatten_image_array_shape[2])

#print(image_array.shape)
# Convert input to a NumPy array
image_tensor = tf.convert_to_tensor(flatten_image_array_shape, dtype=tf.float32)

# Make a prediction using the loaded model and input data
output = model.predict(flatten_image_array_shape)
prediction_index = np.argmax(output)
# Print the prediction output
print(output)
print(prediction_index)

