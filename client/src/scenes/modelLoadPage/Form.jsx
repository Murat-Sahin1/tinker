import { useState } from "react";
import {
  Box,
  Button,
  TextField,
  useMediaQuery,
  Typography,
  useTheme,
} from "@mui/material";
import EditOutlinedIcon from "@mui/icons-material/EditOutlined";
import { Formik } from "formik";
import * as yup from "yup";
import { useNavigate } from "react-router-dom";
import { useDispatch } from "react-redux";

import Dropzone from "react-dropzone";
import FlexBetween from "components/FlexBetween";

import axios from "axios";

const modelSchema = yup.object().shape({
  modelFile: yup.string().required("Required"),
  inputType: yup.string().required("Required"),
  inputFiles: yup.string().required("Required"),
});

const initialValues = {
  modelFile: "",
  inputType: "",
  inputFiles: [],
};

const Form = ({ onModelNameChange }) => {
  const { palette } = useTheme();
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const isNonMobile = useMediaQuery("(min-width:600px)");
  const [modelName, setModelName] = useState();

  const handleModelNameChange = (modelName) => {
    setModelName(modelName);
    onModelNameChange(modelName);
  };

  const sendModelFile = async (values, onSubmitProps) => {
    console.log(values);
    const formData = new FormData();
    formData.append("modelFile", values.modelFile);
    formData.append("inputType", values.inputType);
    formData.append("inputFiles", values.inputFiles);
    console.log(formData);
    try {
      const res = await axios.post(
        "http://localhost:5074/api/File/Upload",
        formData
      );
      handleModelNameChange(res.data);
      console.log(res);
    } catch (ex) {
      console.log(ex);
    }
  };

  const handleFormSubmit = async (values, onSubmitProps) => {
    console.log(values);
    await sendModelFile(values, onSubmitProps);
  };

  return (
    <Formik
      onSubmit={handleFormSubmit}
      initialValues={initialValues}
      validationSchema={modelSchema}
    >
      {({
        values,
        errors,
        touched,
        handleBlur,
        handleChange,
        handleSubmit,
        setFieldValue,
        resetForm,
      }) => (
        <form onSubmit={handleSubmit}>
          <Box
            mt="2rem"
            marginb="2rem"
            display="grid"
            gap="30px" // between items
            gridTemplateColumns="repeat(4, minmax(0, 1fr))"
            sx={{
              "& > div": { gridColumn: isNonMobile ? undefined : "span 4" },
            }}
          >
            <>
              <TextField
                label="InputType"
                onBlur={handleBlur} // Handles when clicked away
                onChange={handleChange} //Handles when typing
                value={values.inputType}
                name="inputType"
                sx={{ gridColumn: "span 4", justifyContent: "center" }}
              />
              <Box
                gridColumn="span 4"
                border={`1px solid ${palette.neutral.medium}`}
                borderRadius="5px"
                padding="1rem"
              >
                <Dropzone
                  acceptedFiles=".h5"
                  multiple={false}
                  onDrop={(acceptedFiles) => {
                    setFieldValue("modelFile", acceptedFiles[0]);
                  }}
                >
                  {({ getRootProps, getInputProps }) => (
                    <Box
                      {...getRootProps()}
                      border={`2px dashed ${palette.primary.main}`}
                      p="1rem"
                      sx={{ "&:hover": { cursor: "pointer" } }}
                    >
                      <input {...getInputProps()} />
                      {!values.modelFile ? (
                        <p>Add Model File Here</p>
                      ) : (
                        <FlexBetween>
                          <Typography>{values.modelFile.name}</Typography>
                          <EditOutlinedIcon />
                        </FlexBetween>
                      )}
                    </Box>
                  )}
                </Dropzone>
              </Box>
              <Box
                gridColumn="span 4"
                border={`1px solid ${palette.neutral.medium}`}
                borderRadius="5px"
                padding="1rem"
              >
                <Dropzone
                  acceptedFiles=".jpeg,.jpg,.png"
                  multiple={true}
                  onDrop={(acceptedFiles) => {
                    setFieldValue("inputFiles", acceptedFiles);
                    console.log(values.inputFiles);
                    console.log(acceptedFiles);
                  }}
                >
                  {({ getRootProps, getInputProps }) => (
                    <Box
                      {...getRootProps()}
                      border={`2px dashed ${palette.primary.main}`}
                      p="1rem"
                      sx={{ "&:hover": { cursor: "pointer" } }}
                    >
                      <input {...getInputProps()} />
                      {values.inputFiles.length === 0 ? (
                        <p>Provide 10 input files of the stated type.</p>
                      ) : (
                        <Box display="flex" gap="0.5rem" alignContent={"center"} alignItems={"center"} justifyContent={"center"}>
                          <Box display="block">
                            {values.inputFiles.map((inputFile, index) => (
                              <Typography key={index}>
                                {inputFile.name}
                              </Typography>
                            ))}
                          </Box>
                          <Box>
                            {" "}
                            <EditOutlinedIcon />
                          </Box>
                        </Box>
                      )}
                    </Box>
                  )}
                </Dropzone>
              </Box>
            </>
          </Box>

          {/* BUTTONS */}
          <Box mb="15px">
            <Button
              type="submit"
              display="flex"
              sx={{
                m: "2rem 0",
                p: "1rem",
                width: "65%",
                backgroundColor: palette.primary.main,
                color: palette.background.alt,
                "&:hover": { color: palette.primary.main },
              }}
            >
              LOAD THE MODEL
            </Button>
            <Typography
              sx={{
                textDecoration: "underline",
                color: palette.primary.main,
                "&:hover": { cursor: "pointer", color: palette.primary.light },
              }}
            >
              Click here to get assistance.
            </Typography>
            {modelName && (
              <Typography
                sx={{
                  marginTop: "2rem",
                  fontSize: "1rem",
                  color: "#50C878",
                  "&:hover": {},
                }}
              >
                <Box>Successful! Your Model ID:</Box>
                <Box>{modelName}</Box>
              </Typography>
            )}
          </Box>
        </form>
      )}
    </Formik>
  );
};

export default Form;
