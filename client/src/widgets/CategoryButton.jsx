import { styled } from "@mui/material/styles";
import { Box } from "@mui/material";
import FlexBetween from "components/FlexBetween";
import Typography from "@mui/material/Typography";
import { useTheme } from "@emotion/react";
import UserImage from "components/UserImage";
import LandscapeIcon from "@mui/icons-material/Landscape";

const StyledBox = styled(Box)({
  border: `1px solid #291e11`,
  padding: "0.1rem",
  width: "9rem",
  height: "12rem",
  borderRadius: 14,
  display: "flex",
});

function CategoryButton({ icon, categoryName, modelCount }) {
  const theme = useTheme();
  const neutralMain = theme.palette.neutral.mediumMain;
  const neutral = theme.palette.neutral.light;
  const neutralDark = theme.palette.neutral.dark;
  const dark = theme.palette.neutral.dark;
  const background = theme.palette.background.default;
  const primaryLight = theme.palette.primary.light;
  const primaryMain = theme.palette.primary.main;
  const alt = theme.palette.background.alt;

  return (
    <StyledBox
      sx={{
        boxShadow: 3,
        "&:hover": {
          backgroundColor: neutralDark,
          cursor: "pointer",
          transitionDuration: "0.4s",
        },
        "&:not(:hover)": {
          backgroundColor: background,
          transitionDuration: "0.4s",
        },
      }}
    >
      <Box width="100%" display="flex">
        <Box
          display={"flex"}
          flexDirection={"column"}
          justifyContent={"space-evenly"}
          alignItems={"center"}
        >
          {icon === "Image" ? (<LandscapeIcon sx={{ fontSize: 50 }} />) : <></>}

          <Typography
            fontWeight="bold"
            variant="h4"
            color="primary"
            textAlign={"center"}
          >
            {categoryName}
          </Typography>
          <Typography fontSize={"0.8rem"} color={neutralMain}>
            {modelCount} models
          </Typography>
        </Box>
      </Box>
    </StyledBox>
  );
}

export default CategoryButton;
