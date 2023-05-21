import { styled } from "@mui/material/styles";
import { Box } from "@mui/material";
import FlexBetween from "components/FlexBetween";
import Typography from "@mui/material/Typography";
import { useTheme } from "@emotion/react";
import LandscapeIcon from "@mui/icons-material/Landscape";

const StyledBox = styled(Box)({
  border: `1px solid #291e11`,
  padding: "0.1rem",
  width: "90%",
  height: "4rem",
  borderRadius: 9,
  display: "flex",
});

function CategoryListingButton({ icon, categoryName, modelCount }) {
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
        borderWidth: "1px",
        boxShadow: 1,
        borderColor: neutral,
        "&:hover": {
          backgroundColor: neutralDark,
          cursor: "pointer",
          transitionDuration: "0.4s",
          "& .icon": {
            color: background,
            transitionDuration: "0.4s",
          },
        },
        "&:not(:hover)": {
          backgroundColor: background,
          transitionDuration: "0.4s",
        },
      }}
    >
      <Box width="100%" alignItems={"center"} gap="0.2rem" display={"flex"}>
        <Box>
          <LandscapeIcon className="icon" sx={{ fontSize: 50, color: dark }} />
        </Box>
        <Box
          sx={{
            flex: 1,
          }}
          display="flex"
          alignItems={"center"}
          justifyContent={"center"}
          alignSelf={"center"}
          padding="0.5rem"
        >
          <Typography
            justifyContent="center"
            alignItems={"center"}
            color="primary"
            fontWeight="bold"
            variant="h5"
            textAlign={"center"}
          >
            {categoryName}
          </Typography>
        </Box>
      </Box>
    </StyledBox>
  );
}

export default CategoryListingButton;
